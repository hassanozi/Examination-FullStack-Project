import { createBrowserRouter, RouterProvider } from "react-router-dom"
import ChangePass from "./Models/AuthModule/Components/ChangePass/ChangePass"
import ForgetPass from "./Models/AuthModule/Components/ForgetPass/ForgetPass"
import Login from "./Models/AuthModule/Components/Login/Login"
import Register from "./Models/AuthModule/Components/Register/Register"
import ResetPass from "./Models/AuthModule/Components/ResetPass/ResetPass"
import AuthLayout from "./Models/Shared/Components/AuthLayout/AuthLayout"
import NotFound from "./Models/Shared/Components/NotFound/NotFound"
import { ToastContainer } from "react-toastify"



function App() {
  
  const routes = createBrowserRouter([
    { path: '', element: <AuthLayout /> ,errorElement:<NotFound/>,
      children:[
        {index:true, element:<Login/>},
        {path:'login', element:<Login/>},
        {path:'register', element:<Register/>},
        {path:'forget-pass', element: <ForgetPass/>},
        {path:'reset-pass', element: <ResetPass/>},
        {path:'change-pass', element: <ChangePass/>}
      ]},
    // {
    //   path: 'home',element: <ProtectedRoute><MasterLayout/></ProtectedRoute> ,
    //   errorElement:<NotFound/>,
    //   children: [
    //     {index:true, element:<Home/>}
    //   ]
    // }
  ])

  return (
    <>
      <ToastContainer/>
      <RouterProvider router={routes} />

    </>
  )
}

export default App
