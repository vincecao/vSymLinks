# vSymLinks(mklinkGUI)

A GUI verison of Mklink for Windows creating Symbolic Links. Using original mklink in Windows cmd command. Please also check my blog [Symbolic Links](https://vcec.gitlab.io/blog/2018/06/28/symbolic-link/).

_Lineng Cao_

## Screenshot
![](./screenshots/demo.gif)

## Original mklink command in Windows
``` bash
# create a file symbolic link so that typing pad.exe will allow you to launch notepad.exe.
mklink pad.exe notepad.exe

# create a symbolic link called fruit that points directly to the folder oranges.
mklink /D c:\fruit c:\apples\bananas\oranges
```

## vSymLinks Usage
- Drag the file or folder into the form
- Click convert and you can move the Symbolic Links in `SymbolicLinks` to anywhere

## Download
[download exe](./mklinkGUI/bin/Debug/mklinkGUI.exe)