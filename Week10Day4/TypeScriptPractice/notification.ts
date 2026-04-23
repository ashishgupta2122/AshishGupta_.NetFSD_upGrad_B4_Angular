function getWelcomeMessage(name: string): string{
    return `Welcome, ${name} to our application!`;
}

function getUserInfo(name: string, age?: number): string{
    if(age !== undefined){
        return `User: ${name}, Age: ${age}`;
    }
    return `User: ${name}`;
}

function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string{
    return `User: ${name}, Subscription Status: ${isSubscribed ? "Subscribed" : "Not Subscribed"}`;
}

function isEligibleForPremiumFeatures(age: number): boolean{
    return age >= 18;
}

const getAccountStatus = (name: string): string => {
    return `Account status for ${name}: Active`;
}

const NotificationService = {
    appName: "Notification Service",

    sendNotification: (user: string): string => {
    return `Hello ${user}, welcome to ${NotificationService.appName}`;
  },
}

console.log("----Required Parameters----");
console.log(getWelcomeMessage("Ashish"));

console.log("\n----Optional Parameters----");
console.log(getUserInfo("Ashish"));
console.log(getUserInfo("Basu", 30));

console.log("\n----Default Parameters----");
console.log(getSubscriptionStatus("Ashish", true));
console.log(getSubscriptionStatus("Basu"));

console.log("\n----Return Types----");
console.log(isEligibleForPremiumFeatures(20));

console.log("\n----Arrow Functions----");
console.log(getAccountStatus("Ashish"));

console.log("\n---- Lexical this ----");
console.log(NotificationService.sendNotification("Ashish"));