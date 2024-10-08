﻿using System;

namespace H2TechAuction.Models.UserModels.Generators;

public class CPRGenerator
{
    private static readonly Random random = new();

    public static string GenerateCPR()
    {

        DateTime birthDate = GenerateRandomDate();
        string datePart = birthDate.ToString("ddMMyy");

        string sequenceNumber = random.Next(0, 10000).ToString("D4");

        string fullCPR = datePart + sequenceNumber;

        if (birthDate.Year >= 2007)
            return ApplyMod11(fullCPR);

        return fullCPR;
    }
    private static string ApplyMod11(string fullCPR)
    {
        int[] weights = [4, 3, 2, 7, 6, 5, 4, 3, 2];
        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += (fullCPR[i] - '0') * weights[i];
        }

        int remainder = sum % 11;
        int checkDigit = (remainder == 0) ? 0 : 11 - remainder;

        return fullCPR[..9] + checkDigit.ToString();
    }
    private static DateTime GenerateRandomDate()
    {
        int year = random.Next(1900, 2100);
        int month = random.Next(1, 13);
        int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

        return new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
    }
}
