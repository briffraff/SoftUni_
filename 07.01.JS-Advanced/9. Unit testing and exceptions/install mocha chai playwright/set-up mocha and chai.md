# **//SET-UP :  M O C H A and C H A I**

powershell -> run as administrator -> Set-ExecutionPolicy Unrestricted

## 00 - в терминала изпълняваме ->
    setx NODE_PATH %AppData%\npm\node_modules
    set NODE_PATH=%AppData%\npm\node_modules

## 0. правим папка "testFactory" -> десен бутон -> open in integrated terminal.
#### **или стигаме до папката през терминала*

## 1. В терминала изпълняваме -> npm init -y 
#### **папката ще се появи файл **package.json***

## 2.  Във файла "package.json" сменяме 
    "test": "mocha"

## 3.  npm install --global mocha
**инсталираме глобално **MOCHA***
## 4.  npm install --global chai
**инсталираме глобално **CHAI***

## 5.  Във VSCode -> run -> add configuration -> MOCHA TESTS
**би трябвало файлът ,който се отвари да е **workspace.json***

**това ще създаде нова конфигурация/лаунчър ,който можем да намерим в **Run and Debug** (ctrl + shift + d)*

**тази конфигурацията ще ползваме, когато правим тестове*

## 6. В "workspace.json" сменяме следните параметри 

    args:[
       "tdd" със "bdd"
      "#{workspace}/test" със "${file}"
    ]

    "outputCapture": "std",
    "program": "C:/Users/riffraff/AppData/Roaming/npm/node_modules/mocha/bin/_mocha"

## 7.  mkdir test
  - прави папка с име test
  
## 8.  type nul > test.js
  - прави файл с име 'test.js' 

## 9. Run and Debug(ctrl + shift + d)
  - сменяме конфигурацията на - **Mocka Tests(workspace)**



# - УТОЧНЕНИЯ:
-  при смяната на аргументът с **"${file}"** , ще можем да рънваме ,който и да е файл.
  
- ако например искаме да си направим още една конфигурация ,която да рънва единствено и само този "test.js", 
  който създадохме преди малко и ще знаем ,че за момента само там ще пишем тестове.
  Би трябвало да изпълним стъпка 5 и да сменим аргументът по следният начин - **"${workspaceFolder}/testFactory/test"**
  

# - Commands
- **mocha**   
**(проверява дали има файл с име test.js)*

- **module.exports = function name;**  
**(експорт на функция/метод и .т.н)*

- **const chai = require('chai');**  
**(извикване на библиотеката chai)*

# - Powershell : 
- **Get-ExecutionPolicy -List**  
**(извежда лист с рестрикшъни)*

- **Set-ExecutionPolicy -ExecutionPolicy AllSigned -Scope CurrentUser**  
  