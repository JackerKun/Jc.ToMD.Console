# Jc.ToMD.Console

数据库转换MarkDown模块 Jc.ToMD 命令行程序

本程序也是对 ```System.CommandLine``` 库的试验性demo

>依赖环境 .Net6

### Commands
```shell
Description:
  Jc.ToMd.Console
  example: dotnet Jc.ToMD.Console.dll mysql -h 192.168.1.114 -u root -p 
  Password123456. -d YTKHOS

Usage:
  Jc.ToMD.Console [command] [options]

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information

Commands:
  mysql  :Mysql To Markdown

```
### Commands:Mysql

```shell
Description:
  :Mysql To Markdown

Usage:
  Jc.ToMD.Console mysql [options]

Options:
  -h <h>          :HostIp
  -u <u>          :UserName
  -p <p>          :Password
  -d <d>          :Database
  -port <port>    :Port [default: 3306]
  -?, -h, --help  Show help and usage information
```


# 生成结果 示例

# YTKHOS

### t_cfg_menu

***菜单表***

|字段名|数据类型|默认值|是否空|是否主键|注释|
|---|---|---|---|---|---|
|F_MENU_ID|bigint(50)| |NO|PRI|菜单ID|
|F_MENU_NAME|varchar(255)| |YES| |菜单名称|
|F_MENU_URL|varchar(255)| |YES| |菜单相对路径|
|F_MENU_PARENT_ID|bigint(50)|0|YES| |父菜单ID|
|F_REMARK|text| |YES| |备注信息|
|F_ISDELETED|int(2)|0|YES| |是否删除|

### t_cfg_role

***角色表***

|字段名|数据类型|默认值|是否空|是否主键|注释|
|---|---|---|---|---|---|
|F_ROLE_ID|bigint(50)| |NO|PRI|角色ID|
|F_ROLE_Name|varchar(255)| |YES| |角色名称|
|F_CREATETIME|bigint(50)| |YES| |创建时间|
|F_ISDELETE|int(2)|0|YES| |是否删除|

### t_cfg_role_menu

***菜单-角色 对应关系表***

|字段名|数据类型|默认值|是否空|是否主键|注释|
|---|---|---|---|---|---|
|F_ROLE_ID|bigint(50)| |NO| |角色ID|
|F_MENU_ID|bigint(50)| |NO| |菜单ID|

### t_consume_log

***消费记录表***

| 字段名              |数据类型|默认值|是否空|是否主键| 注释                                      |
|------------------|---|---|---|---|-----------------------------------------|
| F_CONSUM_ID      |bigint(20)| |NO|PRI| 消费记录ID                                  |
| F_ORDER_ID       |bigint(20)| |YES| | 订单ID(静态｜动态｜...)                         |
| F_ORDER_TYPE     |int(255)| |YES| | 订单类型(静态                  ｜动态｜...)       |
| F_HOSP_ID        |bigint(20)| |YES| | 医院ID                                    |
| F_ORIGINAL_PRICE |int(10)| |YES| | 原额度                                     |
| F_ISUSECONPON    |int(255)|0|YES| | 是否使用优惠券(是:1                       ｜否:0) |
| F_DESERT_PRICE   |int(10)| |YES| | 优惠后额度                                   |
| F_CASH_PRICE     |int(10)|0|YES| | 现金账户扣费额度                                |
| F_VIRT_PRICE     |int(10)|0|YES| | 虚拟账户扣费额度                                |
| F_CONSUM_STATUS  |int(255)| |YES| | 状态(提交订单,完成消费(给出报告,扣费),退回)               |
| F_CONSUM_REMARK  |varchar(255)| |YES| | 备注(退回原因啥的)                              |
| F_CONSUM_TIME    |bigint(20)| |YES| | 创建时间                                    |
