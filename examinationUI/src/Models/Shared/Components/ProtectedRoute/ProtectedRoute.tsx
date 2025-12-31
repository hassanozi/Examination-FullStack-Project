import React, { useContext } from 'react'
import { AuthContext } from '../../../../Context/AuthContext';
import { Navigate } from 'react-router-dom';

export default function ProtectedRoute(props:any) {

let {loginData} = useContext(AuthContext);
if (localStorage.getItem('accessToken') || loginData) {
    return props.children
}
else {
    return <Navigate to='/login' />
  
}
}
