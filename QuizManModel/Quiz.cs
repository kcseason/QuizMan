using CommonCore.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuizManModel
{
    public class Quiz : BasicModel
    {
        [BsonElement("CandidateName")]
        public string? CandidateName { get; set; }

        [BsonElement("StartTime")]
        public DateTime? StartTime { get; set; }

        [BsonElement("EndTime")]
        public DateTime? EndTime { get; set; }

        [BsonElement("SetTime")]
        public int? SetTime { get; set; }

        [BsonElement("QuestionNumber")]
        public int? QuestionNumber { get; set; }

        [BsonElement("CorrectNumber")]
        public int? CorrectNumber { get; set; }
        [BsonElement("InCorrectNumber")]
        public int? InCorrectNumber { get; set; }
    }

    public class MyAnswer : BasicModel
    {
        [BsonElement("QuizId")]
        public string? QuizId { get; set; }

        [BsonElement("QuestionId")]
        public string? QuestionId { get; set; }

        [BsonElement("MyAnswerList")]
        public IList<string>? MyAnswerList { get; set; }

        [BsonElement("CorrectAnswerList")]
        public IList<string>? CorrectAnswerList { get; set; }

        [BsonElement("IsCorrect")]
        public bool? IsCorrect { get; set; }
    }
}
