﻿var VehicleNS = (function () {

    var POSSIBLE_WHEELS = 4;

    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    }

    //Creating Propulsion parent "class" and its childs
    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
        throw new Error("Not implemented yet!");
    }

    function Wheel(_radius) {
        this.radius = _radius;
        PropulsionUnit.apply(this, arguments); 
    }

    Wheel.inherit(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        var acceleration = 2 * Math.PI * this.radius;
        return acceleration;
    }

    function PropellingNozzle(_power) {
        this.power = _power;
        this.afterBurnSwitchIsOn = false;
        PropulsionUnit.apply(this, arguments);
    }

    PropellingNozzle.inherit(PropulsionUnit);

    PropellingNozzle.prototype.getAcceleration = function () {
        var acceleration = 0;
        if (!this.afterBurnSwitchIsOn) {
            acceleration = this.power;
        } else {
            acceleration = 2 * this.power;
        }

        return acceleration;
    }

    function Propeller(_numberOfFins) {
        this.numberOfFins = _numberOfFins;
        this.spinDirectionIsClockWise = true;
        PropulsionUnit.apply(this, arguments);
    }
    Propeller.inherit(PropulsionUnit);

    Propeller.prototype.getAcceleration = function () {
        this.acceleration = this.numberOfFins;
        if (spinDirectionIsClockWise == false) {
            this.acceleration *= -1;
        }
        return this.acceleration;
    }

    //Creating Vehicle parent "class" and its childs
    function Vehicle(_speed, _propulsionUnit) {
        this.speed = _speed;
        this.propulsionUnit = _propulsionUnit;
    }

    Vehicle.prototype.accelerate = function () {
        var propulsionUnitsCount = this.propulsionUnit.length;
        for (var i = 0; i < propulsionUnitsCount; i++) {
            this.speed += this.propulsionUnit[i].getAcceleration();
        }
    }

    function LandVehicle(speed, wheels) {
        if (wheels.length != POSSIBLE_WHEELS) {
            throw new Error("Invalid number of wheels for land vehicle!");
        }
        Vehicle.apply(this, arguments);

    }

    LandVehicle.inherit(Vehicle);

    function AirVehicle(speed, propellingNozzle) {
        Vehicle.apply(this, arguments);
    }

    AirVehicle.inherit(Vehicle);

    //Implementing Functionality for switching AirVehicle afterburners On and Off
    AirVehicle.prototype.switchAfterBurnersOn = function () {
        if (!this.propulsionUnits.afterBurnSwitchIsOn) {
            this.propulsionUnits.afterBurnSwitchIsOn = true;
        }
    }

    AirVehicle.prototype.switchAfterBurnersOff = function () {
        if (this.propulsionUnits.afterBurnSwitchIsOn) {
            this.propulsionUnits.afterBurnSwitchIsOn = false;
        }
    }

    function WaterVehicle(_speed, propeller) {
        Vehicle.apply(this, arguments);
    }

    WaterVehicle.inherit(Vehicle);

    //Implementing Functionality for changing spin directions of WaterVehicles
    WaterVehicle.prototype.setSpinDirectionClockWise = function (index) {
        if (!this.propulsionUnits[index].spinDirectionIsClockWise) {
            this.propulsionUnits[index].spinDirectionIsClockWise = true;
        }
    }

    WaterVehicle.prototype.setSpinDirectionCounterClockWise = function (index) {
        if (this.propulsionUnits[index].spinDirectionIsClockWise) {
            this.propulsionUnits[index].spinDirectionIsClockWise = false;
        }
    }

    function AmphibiousVehicle(_speed, wheels, propelers) {
        Vehicle.apply(this, arguments);
        this.terainIsLand = true;
        this.landPropulsingUnit = wheels;
        this.waterPropulsingUnit = propelers;
        if (this.terainIsLand) {
            this.propulsionUnit = this.landPropulsingUnit;
        }
        else {
            this.propulsionUnit = this.waterPropulsingUnit;
        }
    }

    AmphibiousVehicle.inherit(Vehicle);

    //Implementing Functionality for changing amphibian moving mode
    AmphibiousVehicle.prototype.changeTerainToLand = function () {
        if (!this.terainIsLand) {
            this.terainIsLand = true;
        }
    }

    AmphibiousVehicle.prototype.changeTerainToWater = function () {
        if (this.terainIsLand) {
            this.terainIsLand = false;
        }
    }

    AmphibiousVehicle.prototype.accelerate = function () {
        if (this.terainIsLand) {
            var propulsionUnitsCount = this.propulsionUnits.length;
            for (var i = 1; i < propulsionUnitsCount; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else {
            this.speed += this.propulsionUnits[0].getAcceleration();
        }
    }

    return {
        Propeller: Propeller,
        PropellingNozzle: PropellingNozzle,
        Wheel: Wheel,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibiousVehicle: AmphibiousVehicle
    }
})();