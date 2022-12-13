

class PriceCalculator {

    constructor() {
        this.ToStr = 1;
        this.Level = 1;
        this.priceDisplayEl = document.getElementById("priceDisplay");
        this.priceStoreEl = document.getElementById("priceStore");
        let price = this.calculate()
        this.displayPrice(price);
        this.createEventListener(
            {
                id: "durationSelect",
                eventType: 'change',
                eventListenerFn: this.selectorEvent
            })
        this.createEventListener(
            {
                id: "levelSelect",
                eventType: 'change',
                eventListenerFn: this.selectorEvent
            })
    }

    createEventListener({ id, eventType, eventListenerFn } = {}) {
        document.getElementById(id)
            .addEventListener(eventType, (e) => eventListenerFn(e, this))
    }

    selectorEvent(e, that) {

        that[e.target.name] = e.target.value;
        //console.log('level ', that.Level, 'to', that.ToStr);
        let price = that.calculate();
        that.displayPrice(price)
        // this[e.target.name] console.log(e.target.value)
    }

    calculate() {
        return this.ToStr * this.Level * 100
    }

    displayPrice(price) {
        this.priceDisplayEl.innerText = `${price} $`
        this.priceStoreEl.value = price;
    }
}

const calculator = new PriceCalculator()