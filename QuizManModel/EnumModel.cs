namespace QuizManModel
{
    public enum Category
    {
        None = 0,
        SingleChoice = 1,
        MultipleChoice = 2,
        TrueOrFalse = 3,
        FillInTheBlank = 4,
        Other = 5
    }

    public enum Difficulty
    {
        Easy = 0,
        Medium = 1,
        Hard = 2
    }

    public enum QuizType
    {
        PSM1 = 0,
        PSM2 = 1,
        PSM3 = 2
    }

    public enum RightOrWrong 
    {
        NotSure = 0,
        Right = 1,
        Wrong = 2
    }
}
