const userName : string = "Ashish";
let age: number = 22;
const email: string = "ashish@gmail.com";
const isSubscribed: boolean = true;

//type Inference
let city = "Lucknow";
let score = 100;

//update age
age = age + 1;
age++;

//Template Literal
const message = `Hello, my name is ${userName}. I am ${age} years old and my email is ${email}. I am ${isSubscribed ? "subscribed" : "not subscribed"} to the newsletter. I live in ${city} and my score is ${score}.`;

//operators
const isEligibleToVote = age >= 18;
const canSubscribe = isSubscribed && age >= 18;

//output
console.log(message);
console.log("city:", city);
console.log("score:", score);
console.log("Eligible to vote:", isEligibleToVote);
console.log("Can subscribe:", canSubscribe);