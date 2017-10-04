# WebFormz
Tool to automate WebFormZ Build

# Usage

Add the webforms you want to build to `WebFormZ.xml`. You can find the form number and key from the webform table. If you want to add custom javascript to the webform, specify the filepath starting from \Shared_Content and the javascript type 1 = ActionA, 2 = ActionC, 3 = ActionN

```xml
<webformz>
  <item webformzno="" webformzkey="" filepath="" customjavascript=""/>
</webformz>
```

Add the name of the environment in `App.config`

```xml
<add key="domain" value=""/>
```

Then just run the exe and enter your iMIS username and password.
