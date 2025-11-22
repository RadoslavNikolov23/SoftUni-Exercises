function solve(inputArr) {

  class Student {
    constructor(username, email, credits) {
      this.username = username;
      this.email = email;
      this.credits = credits;
    }
  }

  class Course {
    constructor(name, capacity) {
      this.name = name;
      this.capacity = capacity;
      this.studentList = [capacity];
    }

    addStudent(student) {
      if (this.capacity > 0) {
        this.studentList.push(student);
        this.capacity--;
        return true;
      }
      return false;
    }
  }

    const patterns= {
        course:/^([\w#]+):\s+(\d+)$/,
        student:/^(\w+)\[(\d+)\]\s+with\s+email\s+([\w@.]+)\s+joins\s+([\w#]+)$/
    }

    let courses = {};

    for(let element of inputArr){
        let courseMatch = element.match(patterns.course);
        let studentMatch = element.match(patterns.student);

        if(courseMatch){

            let [_, courseName, capacity]=courseMatch;
            capacity=Number(capacity);

            if(!courses[courseName]){

                let course=new Course(courseName, capacity);
                courses[courseName]=course;

            } else {

                courses[courseName].capacity+=capacity;
            }

        } else if(studentMatch){

            let [_, username, credits, email, courseName]=studentMatch;
            credits=Number(credits);

            if(courses[courseName]){
                let student=new Student(username, email, credits);
                courses[courseName].addStudent(student);
            }

        }
    }

    let sortedCourses=Object.values(courses)
                            .sort((a,b)=>b.studentList.length - a.studentList.length);

    for(let course of sortedCourses){
        console.log(`${course.name}: ${course.capacity} places left`);

        let sortedStudents=course.studentList
                                  .sort((a,b)=>b.credits - a.credits);

        for(let student of sortedStudents){
            if(student instanceof Student){
                console.log(`--- ${student.credits}: ${student.username}, ${student.email}`);
            }
        }
    }
}

solve([
  "JavaBasics: 2",
  "user1[25] with email user1@user.com joins C#Basics",
  "C#Advanced: 3",
  "JSCore: 4",
  "user2[30] with email user2@user.com joins C#Basics",
  "user13[50] with email user13@user.com joins JSCore",
  "user1[25] with email user1@user.com joins JSCore",
  "user8[18] with email user8@user.com joins C#Advanced",
  "user6[85] with email user6@user.com joins JSCore",
  "JSCore: 2",
  "user11[3] with email user11@user.com joins JavaBasics",
  "user45[105] with email user45@user.com joins JSCore",
  "user007[20] with email user007@user.com joins JSCore",
  "user700[29] with email user700@user.com joins JSCore",
  "user900[88] with email user900@user.com joins JSCore",
]);

solve([
  "JavaBasics: 15",
  "user1[26] with email user1@user.com joins JavaBasics",
  "user2[36] with email user11@user.com joins JavaBasics",
  "JavaBasics: 5",
  "C#Advanced: 5",
  "user1[26] with email user1@user.com joins C#Advanced",
  "user2[36] with email user11@user.com joins C#Advanced",
  "user3[6] with email user3@user.com joins C#Advanced",
  "C#Advanced: 1",
  "JSCore: 8",
  "user23[62] with email user23@user.com joins JSCore",
]);
