'use strict';

//variables
const cardItem = document.querySelector('.card-item');
const cardBtn = document.querySelector('.btn-shop');
const closeCardBtn = document.querySelector('.ci-close');
const cardNumber = document.querySelector('.cart-number');
const foodTitle = document.querySelector('.food-title');
const totalPrice = document.querySelector('.card-action--price');
const productDOM = document.querySelector('.products');
const cardContent = document.querySelector('.card-content');
const cardAction = document.querySelector('.card-action');
// const cartTable = document.querySelector('.cart-table');

//cart
let cart = [];
//buttons
let buttonsDOM = [];

//resetting values
// cardNumber.innerText = 0;
// totalPrice.innerText = `$${0}`;
// getting the products
class Products {
    async getProducts() {
        try {
            let result = await fetch('products.json');
            let data = await result.json();
            let products = data.items;

            products = products.map((item) => {
                const { title, price } = item.fields;
                const { id } = item.sys;
                const image = item.fields.image.fields.file.url;

                return { title, price, id, image };
            });
            return products;
        } catch (error) {
            console.log(error);
        }
    }
}

// display products
class UI {
    displayProducts(products) {
        let result = '';
        products.forEach((product) => {
            result += `
             <div class="col">
                                    <div class="product-info">
                                        <div class="product-img">
                                            <img src="${product.image}" alt="Product image" />
                                        </div>

                                        <h4>
                                            <a href="#">${product.title}</a>
                                        </h4>
                                        <div class="rc-ratings">
                                            <span class="fa fa-star active"></span>
                                            <span class="fa fa-star active"></span>
                                            <span class="fa fa-star active"></span>
                                            <span class="fa fa-star"></span>
                                            <span class="fa fa-star"></span>
                                        </div>
                                        <div class="product-price">$${product.price}</div>

                                        <div class="shop-meta">
                                            <a href="#" data-id="${product.id}" class="btn-bag">
                                                <i class="fa fa-shopping-cart"></i>
                                                Add to cart
                                            </a>
                                        </div>
                                    </div>
                                </div>
        `;
        });
        productDOM.innerHTML = result;
    }

    getBagButtons() {
        const buttons = [...document.querySelectorAll('.btn-bag')];
        buttonsDOM = buttons;
        buttons.forEach((button) => {
            let id = button.dataset.id;

            let inCart = cart.find((item) => item.id === id);

            if (inCart) {
                button.innerText = 'Added';
                button.disabled = true;
            }
            button.addEventListener('click', (e) => {
                e.preventDefault();
                e.target.innerText = 'Added';
                e.target.disabled = true;

                //get product from products
                let cartItem = { ...Storage.getProduct(id), amount: 1 };
                //add product to the cart
                cart = [...cart, cartItem];
                //save cart in local storage
                Storage.saveCart(cart);
                // set cart values
                this.setCartValues(cart);
                // display cart item
                this.addCartItem(cartItem);
                // show the cart
            });
        });
    }
    setCartValues(cart) {
        let tempTotal = 0;
        let itemsTotal = 0;

        cart.map((item) => {
            tempTotal += item.price * item.amount;
            itemsTotal += item.amount;
        });
        cardNumber.innerText = itemsTotal;
        totalPrice.innerText = `$${parseFloat(tempTotal.toFixed(2))}`;
    }

    addCartItem(item) {
        const div = document.createElement('div');
        const div2 = document.createElement('div');
        div.classList.add('card-item');
        div2.classList.add('product-container');

        div.insertAdjacentHTML(
            'afterbegin',
            ` 
          <div class="card-item--image">
          <img src="${item.image}" alt="Card Image"/>
           </div>
             <div class="card-item--article">
            <a href="#" class="card-item--link">${item.title}</a>
            <span class="card-item--price">${item.price}</span>
            <span class="card-item--quantity">x ${item.amount}</span>
           <i class="fa fa-times ci-close" data-id=${item.id}></i>
        </div>
        `
        );

        div2.insertAdjacentHTML(
            'afterbegin',
            `
        <thead>
                    <tr>
                      <th>&nbsp;</th>
                      <th>&nbsp;</th>
                      <th>Product</th>
                      <th>Price</th>
                      <th>Quantity</th>
                      <th>Total</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>
                        <a href="#" class="remove">
                          <i class="fa fa-times"></i>
                        </a>
                      </td>
                      <td>
                        <a href="#">
                          <img src="images/check1.png" alt="checkout image">
                        </a>
                      </td>
                      <td>
                        <a href="shop-full.html">
                          Delicious Food Name
                        </a>
                      </td>
                      <td>
                        <span class="amount">$69.99</span>
                      </td>
                      <td>
                        <div class="quantity">
                          1
                        </div>
                      </td>
                      <td>
                        <span class="amount">$99.99</span>
                      </td>
                    </tr> `
        );

        cardContent.appendChild(div);
        // cartTable.appendChild(div2);
        // console.log(cardContent);
    }

    setupAPP() {
        cart = Storage.getCart();
        this.setCartValues(cart);
        this.populate(cart);
    }
    populate(cart) {
        cart.forEach((item) => this.addCartItem(item));
    }
    cartLogic() {
        cardContent.addEventListener('click', (e) => {
            // const item = Array.from(e.target.children);
            // console.log(item.chilhNodes);
            // item.forEach((i) => {
            //     cardContent.innerHTML = '';
            //     if (!i.classList.contains('.card-item')) {
            //         return;
            //     }
            // });
        });
    }
    removeItem(id) {
        cart = cart.filter((item) => item.id !== id);
        this.setCartValues(cart);
        Storage.saveCart(cart);
        let button = this.getSingleButton(id);
        button.disabled = false;
        button.innerHTML = `<i class="fas fa-shopping-cart"></i>`;
    }
    getSingleButton(id) {
        return buttonsDOM.find((button) => button.dataset.id === id);
    }
}

//local storage
class Storage {
    static saveProducts(products) {
        localStorage.setItem('products', JSON.stringify(products));
    }
    static getProduct(id) {
        let products = JSON.parse(localStorage.getItem('products'));

        return products.find((product) => product.id === id);
    }
    static saveCart(cart) {
        localStorage.setItem('cart', JSON.stringify(cart));
    }
    static getCart() {
        return localStorage.getItem('cart') ? JSON.parse(localStorage.getItem('cart')) : [];
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const ui = new UI();
    const products = new Products();
    // setup app
    ui.setupAPP();
    //get all products
    products
        .getProducts()
        .then((products) => {
            ui.displayProducts(products);
            Storage.saveProducts(products);
        })
        .then(() => {
            ui.getBagButtons();
            ui.cartLogic();
        });
});
