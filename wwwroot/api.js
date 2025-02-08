
function get(endpoint, params) {
    let url = endpoint + "?" + params.join("&");
    let value = fetch(url, {
        method: "GET",
    });
    return value;
}