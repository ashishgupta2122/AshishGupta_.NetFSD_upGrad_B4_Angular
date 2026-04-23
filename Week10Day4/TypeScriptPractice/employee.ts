class Employee {
    public id: number;
    protected name: string;
    private salary: number;

    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    //Getter
    public getSalary(): number{
        return this.salary;
    }

    public setSalary(value: number): void{
        if(value > 0) {
            this.salary = value;
        } else {
            console.log("Salary must be greater than 0");
        }
    }

    public displayDetails(): void {
    console.log(`Employee ID: ${this.id}`);
    console.log(`Name: ${this.name}`);
    console.log(`Salary: ${this.salary}`);
  }
}

class Manager extends Employee {
    public teamSize: number;

    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }

    public displayDetails(): void {
        super.displayDetails();
        console.log(`Team Size: ${this.teamSize}`);
    }
}

const emp1 = new Employee(1, "Ashish", 50000);
emp1.displayDetails();

emp1.setSalary(55000);
console.log(`Updated Salary: ${emp1.getSalary()}`);

const manager1 = new Manager(2, "Basu", 80000, 5);
manager1.displayDetails();