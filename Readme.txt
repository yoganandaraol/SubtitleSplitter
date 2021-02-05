#################################################################
#		Subtitle Splitter				#
#################################################################

Author			:	Yogananda Rao Locherla
Technology Stack	:	ASP.NET MVC4, AngularJs 1.6, C# 4.5
Unit Testing		:	NUnit3, Moq
Other Testing Tools	:	PostMAN (Web API testing)
Development Method	:	TDD - Test Driven Development
Project Solution	:	SubtitleSplitter
Number of Projects	:	4 Projects

						1. Unit testing Project (Name - SubtitleSplitter.Tests) 
						2. Class Library (Name - SubtitleSplitterManager)
						3. Console Application (Name - SubtitleSplitter)
						4. Web Application [ASP.NET MVC, Web API, AngularJs] (Name - SubtitleSplitter.Web)
[Please read the 'SubtitleSplitter_Readme_Yogananda_Rao_Locherla_Final.pdf' document for more details including screenshots]

1. Unit testing Project (Name - SubtitleSplitter.Tests)

	This module is for Unit testing the logic written for the features in SubtitleSplitterManager
	Nuget packages used - NUnit 3.x and Moq
	Moq pacakges are used to wireup the Setup and Teardown features to create and nullify the common objects.
	It has 14 test cases validated for various scenarios
	
2. Class Library (Name - SubtitleSplitterManager)
	
	This module has encapsulated with whole logic needed for Subtitle Splitter project. 
	It has main class named "StringManipulations" which implements IStringSplitRules, IBeautifier
		IBeautifier --> Interface
		------------------------- 
			-> Contains Beautify() abstract function, which is intended to beautify the input string.
			-> Beautify() implemented to remove unnecessary white spaces in it. But we can extend as needed.
		
		IStringSplitRules --> Interface
		-------------------------------
			-> Contains ApplyStringSplitRules() abstract function, which is intended to apply rules mentioned in requirements.
		
		StringManipulations	--> Class 
		-----------------------------
			-> Implements IStringSplitRules, IBeautifier interfaces
			-> Regular Expressions are used to implement Beautify() method
			-> Followed "Red - Green - Refactor" process to improvise the code base


3. Console Application (Name - SubtitleSplitter)
	
	Client application to render the results in UI

4. Web Application (Name - SubtitleSplitter.Web)

	Another Client Application to render the results in UI
	Technology Stack - [ASP.NET MVC, Web API, C#, AngularJs, Bootstrap]

		ASP.NET MVC
		-----------
			-> Model - Subtitle.cs
					Having 2 properties
						SubtitleText
						FormattedSubtitleText

			-> View	 -  Home --> Index.cshtml
					It has following sctions
						Subtitles input section in text area
						Button to perform ajax call to pull the subtitles
						Splitted subtitles rendering in 3 styles..
							1) Displaying the Current Subtitle
							2) List all the subtitle line vise
							3) HIGHLIGHTING the current text in YELLOW color.
		
			-> Controller - Used AngularJS for Controller part
					Directory - ../Angular/app.js
					Used following services to achieve the above functionality
						$http
						$scope
						$timeout
						$interval
					The code written in AngularJS is compatible to minification
					 
		Web API Controller
		------------------
			-> API Controller - SubtitleSplitterController.cs 
					"FormatAndParseTheMessage" is the Action method exposed with returns List of Subtitles

						

#################################################################
#					Subtitle Splitter							#
-----------------------------------------------------------------
	Owner		:	Yogananda Rao Locherla
#################################################################


    


