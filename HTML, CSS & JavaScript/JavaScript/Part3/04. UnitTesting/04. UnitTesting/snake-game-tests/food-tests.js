//Task 5:

module("Food.init");

test("Creating food with possition 15 15", function () {
    var food = new snakeGame.Food({ x: 15, y: 15 }, 10, "#0000ff", "#00ff00");

    equal(food.position.x, 15, "Food possition x set correctly");
    equal(food.position.y, 15, "Food possition y set correctly");
    equal(food.size, 10, "Food size set correctly");
});

 