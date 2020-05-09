// DumbCalculator.CppPort.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <string_view>
#include <vector>
#include <map>

const std::string HelpInfo = R"(Supported commands:
? ->print this help.
q->quit.
dump->dump the contents of the stack and all variables.
[any decimal number]->push that number onto the stack.
+ ->Pop the top 2 items on the stack, add them, push result onto the stack.
- ->Pop the top 2 items on the stack, subtract the top from the one under it, push result onto the stack.
* ->Pop the top 2 items on the stack, multiply them, push result onto the stack.
/ ->Pop the top 2 items on the stack, divide the top into the one under it, push result onto the stack.
= [name]->pop the top of the stack and store it into a variable named `name`.
$[name]->retrieve the value of the variable named `name` and push it onto the stack.)";

static std::vector<double> Stack;
static std::map<std::string, double> Variables;

void WriteLine(std::string message)
{
	std::cout << message << std::endl;
}

bool TryParseDouble(std::string input, double& result) {
	try
	{
		result = std::stod(input);
		return true;
	}
	catch (...) {
		return false;
	}
}

namespace {
	int Applesauce (std::string& input) {
	double number;
	if (TryParseDouble(input, number))
	{
		Stack.push_back(number);
	}
	else if (std::string::npos != input.rfind('=', 0))
	{
		if (Stack.empty())
		{
			WriteLine("Nothing to store! Variable unaltered.");
		}
		else
		{
			Variables[input.substr(1)] = Stack.back();
			Stack.pop_back();
		}
	}
	else if (std::string::npos != input.rfind('$', 0))
	{
		Stack.push_back(Variables[input.substr(1)]);
	}
	else if (input.compare("?") == 0)
	{
		WriteLine(HelpInfo);
	}
	else if (input.compare("+") == 0)
	{
		if (Stack.size() < 2)
		{
			WriteLine("Not enough values to add! Please push more onto the stack and try again.");
		}
		else
		{
			double top = Stack.back();
			Stack.pop_back();
			double second = Stack.back();
			Stack.pop_back();
			Stack.push_back(second + top);
		}
	}
	else if (input.compare("-") == 0)
	{
		if (Stack.size() < 2)
		{
			WriteLine("Not enough values to add! Please push more onto the stack and try again.");
		}
		else
		{
			double top = Stack.back();
			Stack.pop_back();
			double second = Stack.back();
			Stack.pop_back();
			Stack.push_back(second - top);
		}
	}
	else if (input.compare("*") == 0)
	{
		if (Stack.size() < 2)
		{
			WriteLine("Not enough values to add! Please push more onto the stack and try again.");
		}
		else
		{
			double top = Stack.back();
			Stack.pop_back();
			double second = Stack.back();
			Stack.pop_back();
			Stack.push_back(second * top);
		}
	}
	else if (input.compare("/") == 0)
	{
		if (Stack.size() < 2)
		{
			WriteLine("Not enough values to add! Please push more onto the stack and try again.");
		}
		else
		{
			double top = Stack.back();
			Stack.pop_back();
			double second = Stack.back();
			Stack.pop_back();
			Stack.push_back(second / top);
		}
	}
	else if (input.compare("dump") == 0)
	{
		WriteLine("Variables:");
		for (auto& variable : Variables)
		{
			std::cout << " " << variable.first << " := " << variable.second << std::endl;
		}
		WriteLine("Stack");
		for (auto& value : Stack)
		{
			std::cout << " " << value << std::endl;
		}
	}
	else if (input.compare("q") == 0)
	{
		WriteLine("Quitting now.");
		std::getline(std::cin, input);
		return 0;
	}
	else
	{
		WriteLine("I have no idea what you mean. Use ? to ask for help if you want it.");
	}
};
}
int main()
{
	std::cout << "Hello World!\n";
	WriteLine(
		"I wish to do your bidding! I'm an RPN interpreter! I also support variables. Use the special command ? to get help.");
	while (true)
	{
		std::cout << "> ";
		std::string input;
		std::getline(std::cin, input);

		Applesauce(input);
	}
}