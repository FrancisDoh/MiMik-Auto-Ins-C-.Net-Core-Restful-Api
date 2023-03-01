using MySql.Data.MySqlClient;
using System.Data;
using MiMik_Auto_Ins_RestfulApi.Models.DTOs;

public interface IPolicyRepository
{
    Task AddAsync(Policy policy);

    Task DeleteAsync(int id);

    Task<List<Policy>> GetAllAsync();

    Task<Policy> GetByIdAsync(int id);

    Task UpdateAsync(Policy policy);
}

public class PolicyRepository : IPolicyRepository
{
    private readonly IDbConnection _dbConnection;

    public PolicyRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Policy> GetByIdAsync(int id)
    {
        Policy policy = null;

        using (MySqlConnection connection = new MySqlConnection(_dbConnection.ConnectionString))
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM policy WHERE policyID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                policy = new Policy
                {
                    PolicyID = (int)reader["policyID"],
                    BodInjLabCvg = (string)reader["bodInjLabCvg"],
                    PropDamLiabCvg = (string)reader["propDamLiabCvg"],
                    PersInjProtCvg = (string)reader["persInjProtCvg"],
                    PolicyState = (string)reader["policyState"],
                    DateTimeIssued = (string)reader["dateTimeIssued"],
                    DateTimeBeginTerm = (string)reader["dateTimeBeginTerm"],
                    DateTimeEndTerm = (string)reader["dateTimeEndTerm"],
                    PremiumTermAmount = (string)reader["PremiumTermAmount"]
                };
            }
            await reader.CloseAsync();
        }

        return policy;
    }

    public async Task<List<Policy>> GetAllAsync()
    {
        List<Policy> policies = new List<Policy>();

        using (MySqlConnection connection = new MySqlConnection(_dbConnection.ConnectionString))
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM policy", connection);
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                Policy policy = new Policy
                {
                    PolicyID = (int)reader["policyID"],
                    BodInjLabCvg = (string)reader["bodInjLabCvg"],
                    PropDamLiabCvg = (string)reader["propDamLiabCvg"],
                    PersInjProtCvg = (string)reader["persInjProtCvg"],
                    PolicyState = (string)reader["policyState"],
                    DateTimeIssued = (string)reader["dateTimeIssued"],
                    DateTimeBeginTerm = (string)reader["dateTimeBeginTerm"],
                    DateTimeEndTerm = (string)reader["dateTimeEndTerm"],
                    PremiumTermAmount = (string)reader["PremiumTermAmount"]
                };
                policies.Add(policy);
            }
            await reader.CloseAsync();
        }

        return policies;
    }

    public async Task AddAsync(Policy policy)
    {
        using (MySqlConnection connection = new MySqlConnection(_dbConnection.ConnectionString))
        {
            MySqlCommand command = new MySqlCommand(
                "INSERT INTO policy (bodInjLabCvg, propDamLiabCvg, persInjProtCvg, policyState, dateTimeIssued, dateTimeBeginTerm, dateTimeEndTerm, PremiumTermAmount) " +
                "VALUES (@bodInjLabCvg, @propDamLiabCvg, @persInjProtCvg, @policyState, @dateTimeIssued, @dateTimeBeginTerm, @dateTimeEndTerm, @PremiumTermAmount)", connection);
            command.Parameters.AddWithValue("@bodInjLabCvg", policy.BodInjLabCvg);
            command.Parameters.AddWithValue("@propDamLiabCvg", policy.PropDamLiabCvg);
            command.Parameters.AddWithValue("@persInjProtCvg", policy.PersInjProtCvg);
            command.Parameters.AddWithValue("@policyState", policy.PolicyState);
            command.Parameters.AddWithValue("@dateTimeIssued", policy.DateTimeIssued);
            command.Parameters.AddWithValue("@dateTimeBeginTerm", policy.DateTimeBeginTerm);
            command.Parameters.AddWithValue("@dateTimeEndTerm", policy.DateTimeEndTerm);
            command.Parameters.AddWithValue("@PremiumTermAmount", policy.PremiumTermAmount);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }

    public async Task UpdateAsync(Policy policy)
    {
        using (MySqlConnection connection = new MySqlConnection(_dbConnection.ConnectionString))
        {
            MySqlCommand command = new MySqlCommand(
                "UPDATE policy " +
                "SET bodInjLabCvg = @bodInjLabCvg, propDamLiabCvg = @propDamLiabCvg, persInjProtCvg = @persInjProtCvg, " +
                "policyState = @policyState, dateTimeIssued = @dateTimeIssued, dateTimeBeginTerm = @dateTimeBeginTerm, " +
                "dateTimeEndTerm = @dateTimeEndTerm, PremiumTermAmount = @PremiumTermAmount " +
                "WHERE policyID = @id", connection);
            command.Parameters.AddWithValue("@bodInjLabCvg", policy.BodInjLabCvg);
            command.Parameters.AddWithValue("@propDamLiabCvg", policy.PropDamLiabCvg);
            command.Parameters.AddWithValue("@persInjProtCvg", policy.PersInjProtCvg);
            command.Parameters.AddWithValue("@policyState", policy.PolicyState);
            command.Parameters.AddWithValue("@dateTimeIssued", policy.DateTimeIssued);
            command.Parameters.AddWithValue("@dateTimeBeginTerm", policy.DateTimeBeginTerm);
            command.Parameters.AddWithValue("@dateTimeEndTerm", policy.DateTimeEndTerm);
            command.Parameters.AddWithValue("@PremiumTermAmount", policy.PremiumTermAmount);
            command.Parameters.AddWithValue("@id", policy.PolicyID);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(_dbConnection.ConnectionString))
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM policy WHERE policyID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}