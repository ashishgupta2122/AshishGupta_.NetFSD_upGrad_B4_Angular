const cart = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 500, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 },
];

const calculateTotal = (items) =>
    items.reduce((total, item) => total + item.price * item.quantity, 0);


const generateInvoice = (items) => {
    const invoiceLines = items.map(
        (item, index) =>
            `${index + 1}. ${item.name} - ₹${item.price} x ${item.quantity} = ₹${item.price * item.quantity
            }`
    );

    const total = calculateTotal(items);

    return `Shopping Cart Invoice

${invoiceLines.join("\n")}


Total Amount: ₹${total}
`;
};


export { calculateTotal, generateInvoice, cart };