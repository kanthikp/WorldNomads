*******************************************************************
				Numeric Sequence Generator
*******************************************************************
1. The solution has been implemented as APS.Net MVC5 Web application 
2. Takes whole number as input and displays different Numeric sequences.

Technical Details:
	1. Implemented as ASP.Net MVC5 Web application
			1.1. "NumericSequenceCalculator.Web" is the Web application
			1.2. "NumericSequenceCalculator.Web.Tests" contain the unit tests for the controller and SequenceGenerator classes
	2. Showcased Dependency injection using Structuremap
	3. Application can easily be extended if new type of Numeric sequence has to be generated
	3. Used Rhino Mock to implement the unit tests

Assumptions:
	1. Input is a whole number and be between 1 and 100000

How to run this application:
	1. Open the solution file in the visual studio 2013/2012, build and run.
