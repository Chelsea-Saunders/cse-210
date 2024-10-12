
public class PromptGenerator
{
    public List<string> prompts = new List<string>(); //a list of strings

    private Random random = new Random();

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "What is one thing you're grateful for today?  >",
            "What tender mercy from God did you experience today?  >",
            "What was the strongest emotion you felt today and how did you work through it?  >",
            "If there was one thing you could do over today with hindsight, what would it be?  >",
            "How were you a blessing to someone else today?  >",
            "What is one thing you'd like to improve upon tomorrow?  >",
            "What is a scripture that impressed itself upon your mind today?  >", 
            "What is a goal you would like to set for yourself for this week?  >",
            "Where do you see yourself in 5 years from now? From 10 years from now?  >",
            "What is something from this last General Conferencey you want to work on and how will you go about it?  >",
            "If you knew the Savior was coming tomorrow, What would you do different today?  >",
            "If tomorrow was your last day on earth, What would you want to do tomorrow?  >",
            "What was the best part of your  "
        };
    }
    //method to return a random prompt
    public string GetRandomPrompt()
    {
        //check if the list is empty
        if (prompts.Count == 0)
        {
            return "No prompts available"; //message in case of empty list
        }
        //generate a random index between - and the number of prompts
        int randomIndex = random.Next(prompts.Count);

        //error because not returning anything
        //return blank string as a place holder
        //when done it should return a random prompt
        return prompts[randomIndex];
    }
}

//google how to generate a random number in c#
// prompts[randomNumber (the one you generated)]
//[] = index...pulls a random one every time