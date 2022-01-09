const cardItem = document.querySelector('.card-item');
const cardBtn = document.querySelectorAll('.add-button');
const cardBtn_2 = document.querySelector('.btn-shop');
const closeCardBtn = document.querySelector('.ci-close');
const cardNumber = document.querySelector('.cart-number');
const foodTitle = document.querySelector('.food-title');
const totalPrice = document.querySelector('.card-action--price');
const productDOM = document.querySelector('.products');
const cardContent = document.querySelector('.card-content');
const cardAction = document.querySelector('.card-action');
const body = document.querySelector('body');
// const checkout = document.getElementById('checkout');

// const cartTable = checkout.querySelector('.cart-table');
let close;
let amount = 0;
let totalValue = 0;
price = 100;
totalPrice.textContent = `$${0}`;
cardNumber.textContent = 0;

function addToCart(btn) {
    amount++;
    totalValue += price;
    totalPrice.textContent = `$${totalValue}`;
    cardNumber.textContent = amount;
    btn.textContent = 'Added';
    addCartItem();

    cardContent.addEventListener('click', (e) => {
        // const item = e.target;
        // console.log(item);
        // item.forEach((i) => {
        //     if (!i.classList.contains('close')) {
        //         return;
        //     }
        //     cardContent.innerHTML = '';
        // });
    });

    const item = cardContent.querySelector('.card-item--price');
    console.log(item);
    item.addEventListener('click', (e) => {
        console.log(e);
    });
}

cardBtn.forEach((btn) => {
    btn.addEventListener('click', (e) => {
        e.preventDefault();
        addToCart(btn);
    });
});

// eslint-disable-next-line camelcase
if (cardBtn_2) {
    // eslint-disable-next-line camelcase
    cardBtn_2.addEventListener('click', (e) => {
        e.preventDefault();
        console.log(e.target);
        addToCart(cardBtn_2);
    });
}

function addCartItem(item) {
    const div = document.createElement('div');
    const div2 = document.createElement('div');
    div.classList.add('card-item');
    div2.classList.add('product-container');

    div.insertAdjacentHTML(
        'afterbegin',
        ` 
          <div class="card-item--image">
          <img src="images/product1.png" alt="Card Image"/>
           </div>
             <div class="card-item--article">
            <a href="#" class="card-item--link">salam</a>
            <span class="card-item--price">${price}</span>
            <span class="card-item--quantity">x 2</span>
            <button class="close">
            <i class="fa fa-times ci-close" data-id=1></i>
            </button>
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
}
