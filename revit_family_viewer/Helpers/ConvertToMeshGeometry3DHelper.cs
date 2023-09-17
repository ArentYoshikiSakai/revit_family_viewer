using Autodesk.Revit.DB;
using System.Windows.Media.Media3D;

namespace revit_family_viewer.Helpers
{
    public static class ConvertToMeshGeometry3DHelper
    {
        public static MeshGeometry3D ConvertToMeshGeometry3D(GeometryElement geomElem)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            foreach (GeometryObject geomObj in geomElem)
            {
                if (geomObj is Solid solid)
                {
                    foreach (Face face in solid.Faces)
                    {
                        Mesh resultMesh = face.Triangulate();
                        if (resultMesh != null)
                        {
                            int baseIndex = mesh.Positions.Count;
                            foreach (XYZ vertex in resultMesh.Vertices)
                            {
                                mesh.Positions.Add(new Point3D(vertex.X, vertex.Y, vertex.Z));
                            }

                            int numTriangles = resultMesh.NumTriangles;
                            for (int i = 0; i < numTriangles; i++)
                            {
                                MeshTriangle triangle = resultMesh.get_Triangle(i);
                                mesh.TriangleIndices.Add(baseIndex + (int)triangle.get_Index(0));
                                mesh.TriangleIndices.Add(baseIndex + (int)triangle.get_Index(1));
                                mesh.TriangleIndices.Add(baseIndex + (int)triangle.get_Index(2));
                            }
                        }
                    }
                }
            }

            return mesh;
        }

    }
}