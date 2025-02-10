const API = 'http://localhost:3090';

function login(data) {
    fetch(API + "/api/auth/login", { body: data, method: "POST" }).then(value => {
        if (value.ok) {
            value.json().then(user => {
                localStorage.setItem("_u", JSON.stringify(user));
                if (user.role == "Admin") {
                    location.pathname = "/admin";
                } else {
                    location.pathname = "/";
                }
            })
        }
    }).catch(err => {
        Swal.fire({
            title: "خطأ",
            text: "كلمة المرور او اسم المستخدم غير صحيح",
            icon: "error",
            showConfirmButton: false,
            position: "top-end"
        });
    });
}

function handleSubmit(e) {
    e.preventDefault();
    const formData = new FormData(e.target);
    const formProps = Object.fromEntries(formData);
    login(formProps);
}

const loginForm = document.getElementById("login-form");
if(loginForm) loginForm.addEventListener("submit", handleSubmit);