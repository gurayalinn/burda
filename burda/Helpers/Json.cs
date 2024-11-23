using burda.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;


namespace burda.Helpers
{
    public class Json
    {
        public List<RFIDCard> ParseRFIDCards(string json)
        {
            List<RFIDCard> cards = new List<RFIDCard>();

            try
            {
                using (JsonDocument document = JsonDocument.Parse(json))
                {
                    JsonElement root = document.RootElement;

                    if (root.TryGetProperty("rfidCards", out JsonElement cardArray))
                    {
                        foreach (JsonElement cardElement in cardArray.EnumerateArray())
                        {
                            RFIDCard card = new RFIDCard();

                            if (cardElement.TryGetProperty("id", out JsonElement idElement))
                                card.ID = idElement.GetInt64();

                            if (cardElement.TryGetProperty("rfidNumber", out JsonElement rfidNumberElement))
                                card.RFIDNumber = rfidNumberElement.GetString();

                            if (cardElement.TryGetProperty("createdDate", out JsonElement createdDateElement))
                                card.CreatedDate = createdDateElement.GetDateTime();

                            if (cardElement.TryGetProperty("updatedDate", out JsonElement updatedDateElement))
                                card.UpdatedDate = updatedDateElement.GetDateTime();

                            // Parse the RawData as a JSON string
                            if (cardElement.TryGetProperty("rawData", out JsonElement rawDataElement))
                            {
                                // Store the raw JSON of rawData directly
                                card.RawData = rawDataElement.GetRawText();
                            }

                            cards.Add(card);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz JSON formatı: rfidCards array bulunamadı.");
                    }
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON parsing hatası: {ex.Message}");
            }

            return cards;
        }
    }
}
