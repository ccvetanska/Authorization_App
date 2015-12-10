using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Authorization_App.Model
{
    public class TestReport
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonRequired]        
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonRequired]
        [BsonElement("testId")]
        public int TestId { get; set; }

        [BsonRequired]
        [BsonElement("authorId")]
        public string AuthorId { get; set; }

        [BsonRequired]
        [BsonElement("code")]
        public string Code { get; set; }

        [BsonRequired]
        [BsonElement("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [BsonRequired]
        [BsonElement("candidate")]
        public string Candidate { get; set; }

        [BsonRequired]
        [BsonElement("position")]
        public string Position { get; set; }

        [BsonRequired]
        [BsonElement("questionIds")]
        public List<int> QuestionIds { get; set; }

        [BsonRequired]
        [BsonElement("answers")]
        public List<string> Answers { get; set; }

    }
}
