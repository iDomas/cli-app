# CLI App for NordVPN api

This app fetches servers(by country and protocol) and saves data in SQLite daatabse.

**Local sotrage file is created in `Documents` folder**

## How to use?

#### `server_list`

Fetch servers and save to local sotrage

```
./partycli.exe server_list
```

Print locally saved servers:

```
./partycli.exe server_list --local
```

Fetch servers by country and save to storage

```
./partycli.exe server_list -country <country>
```

Fetch servers by Protocol and save to storage

```
partycli server_list --TCP
```

#### `config`

Select config from all available servers

```
./partycli.exe config
```

Display current config

```
./partycli.exe config -c
```
