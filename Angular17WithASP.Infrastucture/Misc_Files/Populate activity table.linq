<Query Kind="Program">
  <Connection>
    <ID>887b7cfc-025b-431c-83f5-b39a4b71dc12</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>DXFullApp</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

//Populate Activity table with 5 random activities for each contact, using LinqPad. One time use and work is already done. In source control for prosperity.

void Main()
{
	var contacts = Contacts.ToList();
	List<Activities> activities = Activities.ToList();
	var activity = new LINQPad.User.Activity();


	var entities = Activity.ToList();
	Activity.RemoveRange(entities);
	SaveChanges();

	foreach (var contact in contacts)
	{
		
		var randomList = SelectRandom(activities, 5);
		foreach (Activities item in randomList)
		{
			activity = new LINQPad.User.Activity();
			activity.ContactId = contact.ID;
			activity.Name = item.Name;
			activity.Date = GetRandomDateTimeIn2023();
			Activity.Add(activity);
			SaveChanges();
		}
		
		
		activities = Activities.ToList();

	}
	
}

public DateTime GetRandomDateTimeIn2023()
{
	Random rand = new Random();
	int month = rand.Next(1, 13); // Month: 1 (January) to 12 (December)
	int day = rand.Next(1, DateTime.DaysInMonth(2023, month) + 1); // Day: 1 to number of days in the selected month
	int hour = rand.Next(0, 24); // Hour: 0 to 23
	int minute = rand.Next(0, 60); // Minute: 0 to 59
	int second = rand.Next(0, 60); // Second: 0 to 59
	DateTime randomDateTime = new DateTime(2023, month, day, hour, minute, second);
	return randomDateTime;
}


	public static List<Activities> SelectRandom(List<Activities> list, int number)
	{
		Random rand = new Random();
		List<Activities> newList = new List<Activities>();
		for (int i = 0; i < number; i++)
		{
			int index = rand.Next(list.Count);
			index.Dump();
			newList.Add(list[index]);
			list.RemoveAt(index);
		}
		return newList;
	}
