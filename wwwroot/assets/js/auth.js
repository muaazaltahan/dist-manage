const API = 'http://localhost:3090';

function login(data) {
    fetch(API + "api/login", { body: data, method: "POST" });
}

function handleSubmit(e) {
    e.preventDefault();
    const formData = new FormData(e.target);
    const formProps = Object.fromEntries(formData);
    login(formProps);
}

const loginForm = document.getElementById("login-form");
loginForm.addEventListener("submit", handleSubmit);