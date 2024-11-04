# Delivery Service

## Description

Filter delivery orders in next half an hour by
first order as filter criteria to the output file.

Usage: filter.exe <command> [options]

Commands:
  help		displays this help message
  config	get filter criteria from JSON config
  order 	get filter criteria from command line parameters

Show help: filter.exe help [command]

Examples:
  Display this help message
    C:\> filter.exe help

  Display full help message
    C:\> filter.exe help full

  Config command help
    C:\> filter.exe help config

  Order command help
    C:\> filter.exe help order

  With PowerShell
    PS C:\> .\filter.exe help

## First order from parameters

Get first order from command line parameters

Usage: filter.exe order <district> <delivery time>

Examples:
  Without quotes
    C:\> filter.exe order 1 12.01.2023_02:21

  With date quotes
    C:\> filter.exe order 1 "12.01.2023 02:21"

  With PowerShell
    PS C:\> .\filter.exe order 1 "12.01.2023 02:21"

## First order from config

Exctract first order from JSON config file. If no
file specified uses default 'resources/config.json'

Usage: filter.exe config [JSON file path]

Examples:
  Default config
    C:\> filter.exe config

  Relative path to config
    C:\> filter.exe config config.json

  Full path without quotes
    C:\> filter.exe config C:/path/config.json

  Use quotes to pass path with spaces
    C:\> filter.exe "config with spaces.json"

  With PowerShell
    PS C:\> .\filter.exe "config with spaces.json"
