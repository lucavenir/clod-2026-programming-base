

Console.WriteLine(88);


string ClassifyPingLatecy(int pingMs)
{
    
         if (pingMs <= 0) 
        return "TIMEOUT";
    
    
         if (pingMs > 400) 
        return "CRITICAL";
    
    
         if (pingMs > 150 && pingMs <= 400) 
        return "SLOW";
    
      else;
      return "FAST";
      
      
    
    
   

}






















