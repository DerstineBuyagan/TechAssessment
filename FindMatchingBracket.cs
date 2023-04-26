using NUnit.Framework;
namespace TechAssessment;

public class Tests
{
    bool FindMatchingBrackets(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (var c in input)
        {
            if (c != '<')
            {
                if (c != '>') continue;
                if (stack.Count == 0 || stack.Pop() != '<')
                {
                    return false;
                }
            }
            else
            {
                stack.Push(c);
            }
        }
        return stack.Count == 0;
    }

    [Test]
    public void Test()
    {
        Assert.Multiple(() =>
        {
            Assert.That(FindMatchingBrackets("<>"), Is.True);
            Assert.That(FindMatchingBrackets("><"), Is.False);
            Assert.That(FindMatchingBrackets("<<>"), Is.False);
            Assert.That(FindMatchingBrackets("\"\""), Is.True);
            Assert.That(FindMatchingBrackets("<abc...xyz>"), Is.True);
        });
    }
}