export default function (state, action) {
    state = state || JSON.parse(localStorage.getItem('for_house_session')) || {
            Token: null,
            User: null
        };
    let new_state;
    switch (action.type) {
        case 'SESSION:UP':
            new_state = {User: action.user};
            localStorage.setItem('for_house_session', JSON.stringify(new_state));
            return new_state;
        case 'TOKEN:SET':
            new_state = Object.assign({}, state, {Token: action.token});
            localStorage.setItem('for_house_session', JSON.stringify(new_state));
            return new_state;
        case 'USER:SET':
            new_state = Object.assign({}, state, {User: action.user});
            localStorage.setItem('for_house_session', JSON.stringify(new_state));
            return new_state;
        case 'SESSION:DOWN':
            localStorage.setItem('for_house_session', null);
            return {User: null};
        default:
            return state;
    }
};