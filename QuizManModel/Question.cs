using CommonCore.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuizManModel
{
    public class Question : BasicModel
    {
        [BsonElement("Topic")]
        public string? Topic { get; set; }

        [BsonElement("AnswerList")]
        public IList<Answer>? AnswerList { get; set; }

        [BsonElement("Explanation")]
        public string? Explanation { get; set; }

        [BsonElement("Difficulty")]
        public Difficulty Difficulty { get; set; } = Difficulty.Medium;

        [BsonElement("Category")]
        public Category Category { get; set; }

        [BsonElement("ShortName")]
        public string? ShortName { get; set; }

        [BsonElement("FullName")]
        public string? FullName { get; set; }
    }

    public class Answer
    {
        [BsonElement("AnswerString")]
        public string? AnswerString { get; set; }
        [BsonElement("RightOrWrong")]
        public RightOrWrong RightOrWrong { get; set; }
        public Answer()
        {
        }
        public Answer(string? _answerString, RightOrWrong _rightOrWrong = RightOrWrong.Wrong)
        {
            AnswerString = _answerString;
            RightOrWrong = _rightOrWrong;
        }
    }
}
