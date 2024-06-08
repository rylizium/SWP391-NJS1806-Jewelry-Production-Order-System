import ProductListing from "./ProductListing"


const ProductPage = ({title,description}) =>{
    return (
        <>  
            <div className="container flex flex-col gap-4 p-10">
                <h1 className="text-3xl text-center cormorant-garamond-regular">{title}</h1>
                <p className="text-center text-gray-500">{description}</p>

            </div>
            <ProductListing></ProductListing>
        </>
    )
}


export default ProductPage