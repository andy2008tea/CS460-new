using System;

// API Imports

/// <summary>
///  Command line postfix calculator.  This code makes use of java.lang.IllegalArgumentException
/// to indicate when there is a problem with the input expression.  I probably should have written my own
/// exception class that is specific to this application, but this one sounds appropriate. 
/// 
/// @author    Scot Morse
/// </summary>
public class Calculator
{
	/// <summary>
	///  Our data structure, used to hold operands for the postfix calculation.
	/// </summary>
	private StackADT stack = new LinkedStack();

	/// <summary>
	/// Scanner to get input from the user from the command line. </summary>
	

	/// <summary>
	///  Entry point method. Disregards any command line arguments.
	/// </summary>
	/// <param name="args">  The command line arguments </param>
	public static void Main(string[] args)
	{
		// Instantiate a "Main" object so we don't have to make everything static
		Calculator app = new Calculator();
		bool playAgain = true;
		Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
		while (playAgain)
		{
			playAgain = app.doCalculation();
		}
		Console.WriteLine("Bye.");
	}

	/// <summary>
	///  Get input string from user and perform calculation, returning true when
	///  finished. If the user wishes to quit this method returns false.
	/// </summary>
	/// <returns>    true if a calculation succeeded, false if the user wishes to quit </returns>
	private bool doCalculation()
	{
		Console.WriteLine("Please enter q to quit\n");
		string input = "2 2 +";
		Console.Write("> "); // prompt user

		input = scin.nextLine();
		// looks like nextLine() blocks for input when used on an InputStream (System.in).  Docs don't say that!

		// See if the user wishes to quit
		if (input.StartsWith("q", StringComparison.Ordinal) || input.StartsWith("Q", StringComparison.Ordinal))
		{
			return false;
		}
		// Go ahead with calculation
		string output = "4";
		try
		{
			output = evaluatePostFixInput(input);
		}
		catch (System.ArgumentException e)
		{
			output = e.Message;
		}
		Console.WriteLine("\n\t>>> " + input + " = " + output);
		return true;
	}


	/// <summary>
	///  Evaluate an arithmetic expression written in postfix form.
	/// </summary>
	/// <param name="input">                         Postfix mathematical expression as a String </param>
	/// <returns>                               Answer as a String </returns>
	/// <exception cref="IllegalArgumentException">  Something went wrong </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String evaluatePostFixInput(String input) throws IllegalArgumentException
	public virtual string evaluatePostFixInput(string input)
	{
		if (string.ReferenceEquals(input, null) || input.Equals(""))
		{
			throw new System.ArgumentException("Null or the empty string are not valid postfix expressions.");
		}
		// Clear our stack before doing a new calculation
		stack.clear();

		string s; // Temporary variable for token read
		double a; // Temporary variable for operand
		double b; // ...for operand
		double c; // ...for answer
        double number;

        char[] separator = { ' ' };
        String[] st = input.Split(separator);
        int i = 0;
        while (i < st.Length)
        {
            if (Double.TryParse(st[i], out number))
            {
                stack.push(number);    // if it's a number push it on the stack
            }
            else
            {
                // Must be an operator or some other character or word.
                s = st[i];
                if (s.Length > 1)
                {
                    throw new ArgumentNullException("Input Error: " + s + " is not an allowed number or operator");
                }
                // it may be an operator so pop two values off the stack and perform the indicated operation
                if (stack.isEmpty())
                {
                    throw new ArgumentNullException("Improper input format. Stack became empty when expecting second operand.");
                }
                b = ((Double)(stack.pop()));
                if (stack.isEmpty())
                {
                    throw new ArgumentNullException("Improper input format. Stack became empty when expecting first operand.");
                }
                a = ((Double)(stack.pop()));
                // Wrap up all operations in a single method, easy to add other binary operators this way if desired
                c = doOperation(a, b, s);
                // push the answer back on the stack
                stack.push(c);
            }
            i++;
        }// End while
        return ((double?)(stack.pop())).ToString();
	}


	/// <summary>
	///  Perform arithmetic.  Put it here so as not to clutter up the previous method, which is already pretty ugly.
	/// </summary>
	/// <param name="a">                             First operand </param>
	/// <param name="b">                             Second operand </param>
	/// <param name="s">                             operator </param>
	/// <returns>                               The answer </returns>
	/// <exception cref="IllegalArgumentException">  Something's fishy here </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public double doOperation(double a, double b, String s) throws IllegalArgumentException
	public virtual double doOperation(double a, double b, string s)
	{
		double c = 0.0;
		if (s.Equals("+")) // Can't use a switch-case with Strings, so we do if-else
		{
			c = (a + b);
		}
		else if (s.Equals("-"))
		{
			c = (a - b);
		}
		else if (s.Equals("*"))
		{
			c = (a * b);
		}
		else if (s.Equals("/"))
		{
			try
			{
				c = (a / b);
				if (c == double.NegativeInfinity || c == double.PositiveInfinity)
				{
					throw new System.ArgumentException("Can't divide by zero");
				}
			}
			catch (ArithmeticException e)
			{
				throw new System.ArgumentException(e.Message);
			}
		}
		else
		{
			throw new System.ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");
		}

		return c;
	}

} // end class Calculator


