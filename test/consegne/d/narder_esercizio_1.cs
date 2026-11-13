List<int> eventCode = [];


foreach(int n in eventCode)
{
    if(n <= 0)
        return "Invalid"; 
  
    if(n % 4 == 0 && n % 6 == 0)
        return "CRITICAL_SYS_APP";

    if(n % 4 == 0)
        return "SYS";
    
    if(n % 6 == 0)
        return "APP";
  
    else
  
        return "eventCode";
  }



    
    
