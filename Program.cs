// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using System.CommandLine.Invocation;
using Jc.ToMD.DbToMd;

/// <summary>
/// 
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        var rootCommand = new RootCommand("Jc.ToMd.Console\r\nexample: dotnet Jc.ToMD.Console.dll mysql -h 192.168.1.114 -u root -p Password123456. -d YTKHOS");

        //注册mysql的命令
        var mysql = new Command("mysql", ":Mysql To Markdown");
        var h = new Option<string>("-h", ":HostIp");
        var u = new Option<string>("-u", ":UserName");
        var p = new Option<string>("-p", ":Password");
        var d = new Option<string>("-d", ":Database");
        var port = new Option<int>(
            name: "-port",
            description: ":Port",
            getDefaultValue: () => 3306);
        mysql.Add(h);
        mysql.Add(u);
        mysql.Add(p);
        mysql.Add(d);
        mysql.Add(port);
 
        mysql.SetHandler(
            (string? h, string? u, string p, string d, int port) =>
            {
                StartToMD(h, u, p, d, port, d + ".md",0);
            }, h, u, p, d, port);

        rootCommand.Add(mysql);
        await rootCommand.InvokeAsync(args);
    }
    
    /// <summary>
    /// 启用转换逻辑
    /// </summary>
    /// <param name="h"></param>
    /// <param name="u"></param>
    /// <param name="p"></param>
    /// <param name="d"></param>
    /// <param name="port"></param>
    /// <param name="file"></param>
    /// <param name="type"></param>
    static void StartToMD(string h, string u, string p, string d, int port, string file,int type)
    {
        try
        {
            if (h == null)
            {
                Console.WriteLine("host is required");
                return;
            }
            
            if (u == null)
            {
                Console.WriteLine("user is required");
                return;
            }
            
            if (p == null)
            {
                Console.WriteLine("password is required");
                return;
            }

            if (d == null)
            {
                Console.WriteLine("database is required");
                return;
            }

            Jc.ToMD.DBToMD dbToMd=null;
            switch (type)
            {
                case 0:
                    dbToMd=new Jc.ToMD.DBToMD(new MysqlToMd(h, d, u, p, port));
                    break;
            }
            bool result = dbToMd.OutToFile(file);
            if (result)
            {
                Console.WriteLine($"Mysql to Markdown success :{new FileInfo(file).FullName}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}