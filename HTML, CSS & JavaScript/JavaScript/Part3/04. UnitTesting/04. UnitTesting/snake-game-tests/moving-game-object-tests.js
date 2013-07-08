//Task 1: 

module("MovingGameObject");

module("MovingGameObject.move");
test("Moving Object value when direction is 0, decrease x",
  function () {
      //(position, size, fcolor, scolor, speed, direction)
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
      console.log(piece);
      piece.move();
      position.x + speed;
      deepEqual(piece.position, position);
  });

test("Moving Object value when direction 1, increase y",
function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
    var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
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

module("MovingGameObject.changeDirection");
test("When  direction is 0, and we want to change it to 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
      piece.changeDirection(3);
      console.log(piece);
      deepEqual(piece.direction, 3);
  });


test("When  direction is 1, and we want to change it to 2",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
      piece.changeDirection(2);
      console.log(piece);
      deepEqual(piece.direction, 2);
  });


test("When  direction is 2, and we want to change it to 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
      piece.changeDirection(3);
      console.log(piece);
      deepEqual(piece.direction, 3);
  });


test("When  direction is 3, and we want to change it to 0",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.MovingGameObject(position, size, "#222222", "#cccccc", speed, dir);
      piece.changeDirection(0);
      console.log(piece);
      deepEqual(piece.direction, 0);
  });

