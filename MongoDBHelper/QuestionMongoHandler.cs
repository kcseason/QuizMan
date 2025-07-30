using MongoDB.Driver;
using QuizManModel;

public class QuestionMongoHandler
{
    private readonly IMongoCollection<Question> _questionsCollection;

    public QuestionMongoHandler(bool isAtlas, string databaseName, string collectionName)
    {
        var connectionString = isAtlas ? "mongodb+srv://admin:admin@cluster0.udbu4nw.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"
                                                                    : "mongodb://localhost:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _questionsCollection = database.GetCollection<Question>(collectionName);
    }

    public QuestionMongoHandler(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _questionsCollection = database.GetCollection<Question>(collectionName);
    }

    public async Task InsertQuestionAsync(Question qt)
    {
        await _questionsCollection.InsertOneAsync(qt);
    }

    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        return await _questionsCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Question> GetUserQuestionByIdAsync(string id)
    {
        var filter = Builders<Question>.Filter.Eq(u => u.Id, id);
        return await _questionsCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateQuestionAsync(Question qt)
    {
        var filter = Builders<Question>.Filter.Eq(u => u.Id, qt.Id);
        await _questionsCollection.ReplaceOneAsync(filter, qt);
    }

    public async Task DeleteQuestionAsync(string id)
    {
        var filter = Builders<Question>.Filter.Eq(u => u.Id, id);
        await _questionsCollection.DeleteOneAsync(filter);
    }
}