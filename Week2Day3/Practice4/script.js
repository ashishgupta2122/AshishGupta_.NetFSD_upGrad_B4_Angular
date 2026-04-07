const products = [
    "iPhone 15",
    "Samsung Galaxy S24",
    "OnePlus 12",
    "Realme Narzo",
    "Redmi Note 13",
    "MacBook Air",
    "Dell Laptop",
    "HP Pavilion",
    "Sony Headphones",
    "Boat Earbuds"
];

let filteredProducts = [...products];


const searchInput = document.getElementById("searchInput");
const productList = document.getElementById("productList");
const noResult = document.getElementById("noResult");


function renderProducts(list) {
    productList.innerHTML = "";

    if (list.length === 0) {
        noResult.style.display = "block";
        return;
    }

    noResult.style.display = "none";

    list.forEach(product => {
        const li = document.createElement("li");
        li.textContent = product;
        productList.appendChild(li);
    });
}

function filterProducts(query) {
    filteredProducts = products.filter(product =>
        product.toLowerCase().includes(query.toLowerCase())
    );

    renderProducts(filteredProducts);
}




searchInput.addEventListener("input", function (e) {
    filterProducts(e.target.value);
});


productList.addEventListener("click", function (e) {
    if (e.target.tagName === "LI") {
        alert("You selected: " + e.target.textContent);
    }
});


renderProducts(products);