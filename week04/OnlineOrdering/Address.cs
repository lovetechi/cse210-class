using System;

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string Street { get { return _street; } }
    public string City { get { return _city; } }
    public string StateOrProvince { get { return _stateOrProvince; } }
    public string Country { get { return _country; } }

    public bool IsInUSA()
    {
        return _country.Trim().ToLower() == "usa" || _country.Trim().ToLower() == "united states" || _country.Trim().ToLower() == "united states of america" || _country.Trim().ToLower() == "us";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
