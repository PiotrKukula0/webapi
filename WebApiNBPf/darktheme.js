// theme switch example for demo
document.getElementById('btnSwitch').addEventListener('click',()=>{
    if (document.body.classList.contains('dark')) {
        document.body.classList.remove('dark')
    }
    else {
        document.body.classList.add('dark')
    }
    document.getElementById('darkTheme').innerText = document.body.classList
})