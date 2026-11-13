
CalculateLicenseCost(1, 18, 33, 49, 66, 90, 55, 3, 44);

double CalculateLicenseCost(int userCount, bool isNonProfit)
{


    var result = 0;
    double isNotProfit = 0;

    {
        {
            if (userCount == isNotProfit)
                result / 2;

            if (userCount <= 0)
                return 0.0;

            if (userCount <= 10)
                return 10.00;

            if (userCount >= 11 || userCount <= 50)
                return 8.00;

            else
                return 5.00;
        }

    }
}