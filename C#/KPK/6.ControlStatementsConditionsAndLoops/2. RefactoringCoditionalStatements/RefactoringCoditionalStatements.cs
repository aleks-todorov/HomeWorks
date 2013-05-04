//Refactoring Potatoes :D 
Potato potato = new Potato();
//...  
if (potato != null)
{
    if( !potato.IsRotten && potato.isPealed)
    {
        Cook(potato);
    }
}

//Refactoring if statement
if ((x >= MIN_X && x =< MAX_X) && (y >= MinY && y =< MAX_Y) && shouldVisitCell)
{
   VisitCell();
}