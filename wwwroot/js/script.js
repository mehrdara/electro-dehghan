const addBtn = document.querySelectorAll(".add-btn");
const removeBtn = document.querySelectorAll(".remove-btn");
const plusBtn = document.querySelectorAll(".plus-btn");
const minusBtn = document.querySelectorAll(".minus-btn");
const cartActionsContainer = document.querySelector(".cart-container");
const itemsInCart = document.getElementById("items-in-cart");
[...plusBtn].forEach((btn) => {
  btn.addEventListener("click", () => {
    let number = parseInt(btn.previousElementSibling.innerText);
    let itemCount = parseInt(itemsInCart.innerText);
    number = number + 1;
    itemCount = itemCount + 1;
    btn.previousElementSibling.innerText = number.toString();
    itemsInCart.innerText = itemCount.toString();
  });
});
[...minusBtn].forEach((btn) => {
  btn.addEventListener("click", () => {
    let number = parseInt(btn.nextElementSibling.innerText);
    let itemCount = parseInt(itemsInCart.innerText);
    number = number - 1;
    itemCount = itemCount - 1;
    btn.nextElementSibling.innerText = number.toString();
    itemsInCart.innerText = itemCount.toString();
    if (number <= 1) {
      btn.parentElement.parentElement.classList.add("hide");
      btn.parentElement.parentElement.previousElementSibling.classList.remove(
        "hide"
      );
    }
  });
});

[...addBtn].forEach((btn) => {
  btn.addEventListener("click", addToCArt);
});
[...removeBtn].forEach((btn) => {
  btn.addEventListener("click", removeFromCart);
});
function addToCArt(e) {
  e.target.nextElementSibling.classList.remove("hide");
  e.target.classList.add("hide");
  let ItemsInCartInt = parseInt(itemsInCart.innerText);
  ItemsInCartInt = ItemsInCartInt + 1;
  itemsInCart.innerText = ItemsInCartInt.toString();
  e.target.nextElementSibling.children.item(0).children.item(1).innerText = "1";
}
function removeFromCart(e) {
  let quantity = parseInt(
    e.target.previousElementSibling.children.item(1).innerText
  );
  let ItemsInCartInt = parseInt(itemsInCart.innerText);
  ItemsInCartInt = ItemsInCartInt - quantity;
  itemsInCart.innerText = ItemsInCartInt.toString();
  e.target.parentElement.classList.add("hide");
  e.target.parentElement.previousElementSibling.classList.remove("hide");
  e.target.previousElementSibling.children.item(1).innerText = "0";
}
