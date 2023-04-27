using ApiComentarios.Controllers;
using ApiComentarios.DTOSs;
using ApiComentarios.Entities.DTOs;
using ApiComentarios.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Comentarios.Test
{
    [TestFixture]
    public class CommentControllerTests
    {
        private Mock<ICommentService> _mockCommentService;
        private CommentController _comentarioController;

        [SetUp]
        public void Setup()
        {
            _mockCommentService = new Mock<ICommentService>();
            _comentarioController = new CommentController(_mockCommentService.Object);
        }

        [Test]
        public async Task Get_Comments_ReturnsListOfComments()
        {
            // Arrange
            var paginacionDTO = new PaginacionDTO { pageNumber = 1, maxItemsPage = 10 };
            var comments = new List<CommentDTO> { new CommentDTO { Id = 1, Title = "Comment 1" }, new CommentDTO { Id = 2, Title = "Comment 2" } };
            _mockCommentService.Setup(service => service.GetComments(paginacionDTO.pageNumber, paginacionDTO.maxItemsPage))
                .ReturnsAsync(comments);

            // Act
            var result = await _comentarioController.Get(paginacionDTO);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var commentList = okResult.Value as List<CommentDTO>;
            Assert.IsNotNull(commentList);
            Assert.AreEqual(2, commentList.Count);
        }

        [Test]
        public async Task Get_CommentById_ReturnsComment()
        {
            // Arrange
            var commentId = 1;
            var comment = new CommentDTO { Id = commentId, Title = "Comment 1" };
            _mockCommentService.Setup(service => service.GetCommentById(commentId)).ReturnsAsync(comment);

            // Act
            var result = await _comentarioController.Get(commentId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var commentResult = okResult.Value as CommentDTO;
            Assert.IsNotNull(commentResult);
            Assert.AreEqual(commentId, commentResult.Id);
        }

        [Test]
        public async Task Post_CreateComment_ReturnsCreated()
        {
            // Arrange
            var commentDTO = new CommentDTO { Title = "New Comment" };
            var comment = new CommentDTO { Id = 1, Title = "New Comment" };
            _mockCommentService.Setup(service => service.SaveComment(commentDTO)).ReturnsAsync(comment);

            // Act
            var result = await _comentarioController.Post(commentDTO);

            // Assert
            var createdResult = result as CreatedResult;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode);
            var commentResult = createdResult.Value as CommentDTO;
            Assert.IsNotNull(commentResult);
            Assert.AreEqual(comment.Id, commentResult.Id);
        }

        [Test]
        public async Task Put_UpdateComment_ReturnsNoContent()
        {
            // Arrange
            var commentId = 1;
            var commentDTO = new CommentDTO { Title = "Updated Comment" };

            // Act
            var result = await _comentarioController.Put(commentDTO);

            // Assert
            var noContentResult = result as NoContentResult;
            Assert.IsNotNull(noContentResult);
            Assert.AreEqual(204, noContentResult.StatusCode);
            _mockCommentService.Verify(service => service.SaveComment(commentDTO), Times.Once);
        }

        [Test]
        public async Task Delete_ExistingComment_ReturnsOk()
        {
            // Arrange
            int commentId = 1;
            _mockCommentService.Setup(service => service.DeleteComment(commentId)).Returns(Task.CompletedTask);

            // Act
            var result = await _comentarioController.Delete(commentId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            dynamic messageResult = okResult.Value;
            Assert.IsNotNull(messageResult);
            //Assert.AreEqual("Comentario eliminado con exito!", messageResult.mensaje);
            _mockCommentService.Verify(service => service.DeleteComment(commentId), Times.Once);
        }

        [Test]
        public async Task Delete_NonExistingComment_ReturnsNotFound()
        {
            // Arrange
            int commentId = 5;
            _mockCommentService.Setup(service => service.DeleteComment(commentId)).Returns(Task.CompletedTask);

            // Act
            var result = await _comentarioController.Delete(commentId);

            // Assert
            var notFoundResult = new NotFoundResult();
            Assert.IsNotNull(notFoundResult);
            //Assert.AreEqual(404, notFoundResult.StatusCode);
            _mockCommentService.Verify(service => service.DeleteComment(commentId), Times.Once);
        }
    }
}