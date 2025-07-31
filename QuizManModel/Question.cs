using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuizManModel
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

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

        [BsonElement("Remark")]
        public string? Remark { get; set; }

        [BsonElement("CreatedBy")]
        public string? CreatedBy { get; set; }
        [BsonElement("CreateTime")]
        public DateTime? CreateTime { get; set; }
        [BsonElement("UpdatedBy")]
        public string? UpdatedBy { get; set; }
        [BsonElement("UpdateTime")]
        public DateTime? UpdateTime { get; set; }
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
