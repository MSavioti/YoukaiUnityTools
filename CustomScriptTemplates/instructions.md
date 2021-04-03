# Custom script templates instructions  

## `Custom inspector creator`  

With the file `CustomInspectorCreator.cs`, made by [LotteMakesStuff](github.com/LotteMakesStuff), 
an option for Custom Editor will be shown on your context menu.  

![Context menu preview](https://gist.githubusercontent.com/LotteMakesStuff/cb63e4e25e5dfdda19a95380e9c03436/raw/426eaa24df0dbddeb2577d761b90f41c77c2fbac/example.png)

## `Monobehaviour templates`

Under the following path:  

> *C:\Program Files\Unity\Hub\Editor\"Editor version folder"\Editor\Data\Resources\ScriptTemplates*  

You will find a file named:  

> *81-C# Script-NewBehaviourScript.cs.txt*

Change the content of this file with content of any file under *MonobehaviourTemplates*
and save, to change the standard Monobehaviour script template when creating new scripts.  

When using the *NamespaceTemplate*, the script `CustomInspectorCreator.cs` will exchange `#PROJECTNAME#` for the project's name.