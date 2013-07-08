module("SnakePiece.init");
test("should set correct values",   
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    equal(piece.position, position)
    equal(piece.size, 15);
    equal(piece.speed, speed);
    equal(piece.direction, dir);
  });

module("SnakePiece.move");
test("When direction is 0, decrease x",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.x - speed;
    deepEqual(piece.position, position);
  });
test("When  direction is 1, decrease update y",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.y - speed;
    deepEqual(piece.position, position);
  });
test("When  direction is 2, increase x",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.x + speed;
    deepEqual(piece.position, position);
  });
test("When  direction is 3, should increase x",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.y + speed;
    deepEqual(piece.position, position);
  });

test("When  direction is 0, decrease x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
      piece.move();
      position.x - speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 1, should decrease y",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
      piece.move();
      position.y - speed;
      deepEqual(piece.position, position);
  });

//Task 2: 
module("SnakePiece.changeDirections");
test("When  direction is 0, and we want to change it to 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(3);
      console.log(piece);
      deepEqual(piece.direction, 3);
  });


test("When  direction is 1, and we want to change it to 2",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(2);
      console.log(piece);
      deepEqual(piece.direction, 2);
  });


test("When  direction is 2, and we want to change it to 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(3);
      console.log(piece);
      deepEqual(piece.direction, 3);
  });


test("When  direction is 3, and we want to change it to 0",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(0);
      console.log(piece);
      deepEqual(piece.direction, 0);
  });

