# ChessWebApp

v1

-Working initial ui interface (javascript, jQuery, CSS, HTML5) ✓  ...bootstrap later

-Chess game class structure C# .. underway

to-do: 

       saving players and game data to Database using Entity Framework

       saving data to Database and TextFile repositories with interfaces, with dynamic access with the use of configuration files, using Factory design pattern
       and other practices..

---------------------------------------------------------------------------------------------------------------------------------------------------------------



v2.

-Chess class structure ready. Pawn movement logic implemented. todo other pieces' logic

-EntityFramework integrated. Working functions atm: AddGame, RestoreGame, AddPlayers, GetPlayers. todo: updateGame after everyMove if move is legal 

-Mapping from Entity.ChessGame to ClassLibrary.Game and vice versa
    
         
---------------------------------------------------------------------------------------------------------------------------------------------------------------

       
v3. 

-The chess table in the database gets updated after every legal move. On page refresh/closign and running app again, the saved gamestate gets loaded into the javascript code and the backend code, to be able to fully resume an old or paused game.

-Fully working user interface & calls to server. 

to-do: 

       ! implement King, Queen, Madman, Horseman, Rook logic. 
       *implement flipTable in ChessClassLibrary in Game.cs to simplify the code in the Piece.TryMove methods
       *implement login functionality, user tracking, spectator mode for lvie games etc
       *other QoL improvements
       

---------------------------------------------------------------------------------------------------------------------------------------------------------------
v4.
       All pieces movement logic implemented except ability to castle for king. 
       to-do: verify if king is in check after every move.  


---------------------------------------------------------------------------------------------------------------------------------------------------------------
v5. Implemented King Check logic,

Improved UI


---------------------------------------------------------------------------------------------------------------------------------------------------------------
v6. Applied Interface Segregation Principle inside the Data folder. And consequently multiple interface dependency injection in Program.cs

Refactored the override ToString() method from the piece classes into the base class by using reflection

---------------------------------------------------------------------------------------------------------------------------------------------------------------
v7. Implemented Pawn promotion using EventHandler<CustomEventArgs> from a singleton Mediator.cs static class
