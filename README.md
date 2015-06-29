# DrawingTool
http://drawing-tool.azurewebsites.net/

##Solution Details

- Application was built in VisualStudio 2013, Using .Net framework 4.5
- There are two ways to see it running: 
  - via web in http://drawing-tool.azurewebsites.net/
  - A console Application: /ConsoleDrawingApp project
- Core application resides in DrawingLibrary project.
- To run unit test you need to use VisualStudio. Here some steps: https://msdn.microsoft.com/en-us/library/ms182470.aspx#RunTestsFromUnitTestExplorer

## Projects Description: 

- DrawingLabriry 	-> Here lives the main logic for the application, it exposes the interface for the drawing process
- DrawingTool.Tests 	-> Unit test to ensure that our application logic is working as expected.
- DrawingTool 		-> Web Application for demo, this application is also published here: http://drawing-tool.azurewebsites.net/
						it's a Web API application.
- ConsoleDrawingApp	-> Console Windows Application for demo, you can run by single command or by batch using an input.txt command file.
 
