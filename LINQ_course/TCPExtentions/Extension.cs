

namespace TCPExtentions
{
    //To extend the functionality of any generic list that is strongly typed
    //with any C# data type including User-Defined types
    public static class Extension
    {
        //Our own extention method, If we want to filter employee records by criteria
        //that we're able to specity through a Lambda expression on a generic list
        //that is strongly type as Employee
        //Step 1. create the signature for thte filter extention method
        //Step 2. 
        public static List<T> Filter<T>(this List<T> records, Func<T, bool> func)//the this keyword in this contex indicates to the compiler that the relevant method can be called on an object of the data type of the relevant parameter in this case a T type
        {
            List<T> filteredList = new(); //The value this method is going to return

            //Looping over the list that this method is taking in
            foreach (T record in records)
            {
                if (func(record)) //passing the delegate filter extention method for each record
                {                               //if func returns true add it, this logic is not implemented in this func
                    filteredList.Add(record);
                }
            }
            return filteredList;
        }
    }
}
