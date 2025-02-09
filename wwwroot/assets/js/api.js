const API = 'http://localhost:3090';
const user = JSON.parse(localStorage.getItem('_u')).token;

function get(endpoint, params) {
    let url = endpoint + "?" + params.join("&");
    let value = fetch(url, {
        method: "GET",
        headers: {
            Authentication: "Bearer " + user.token
        }
    });
    return value;
}

function addProgramsListeners() {

}

function fillProgramsTable(value) {
    let table = document.getElementById('programs-table');
    let tableBody = table.querySelector('tbody');
    value.forEach(element => {
        const html = `<tr>
        <td>
            ${element.name}
        </td>
        <td>
            ${element.startDate}
        </td>
        <td>
            ${element.endDate}
        </td>
        <td>
            <span class="el-edit" data-id="${element.id}"><a href="#"><i
                        class="ti-pencil-alt color-success"></i></a></span>
            <span class="el-delete" data-id="${element.id}"><a href="#"><i class="ti-trash color-danger"></i>
                </a></span>
        </td>
    </tr>`;
    tableBody?.innerHTML += html;
    });
    tableBody?.querySelectorAll('');
}

function getPrograms() {
    get(API + "/Programs").then(v => {
        if (v.ok) {
            v.json().then(data => {
                fillProgramsTable(data);
            })
        }
    });
}

if (location.href.includes("programs")) {
    getPrograms();
}