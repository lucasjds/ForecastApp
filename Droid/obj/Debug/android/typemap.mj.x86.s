	/* Data SHA1: 6fbed0d6876837582bb75834c9cc39c82bf0d6f5 */
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	3
	/* entry-length */
	.long	109
	/* value-offset */
	.long	55
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
	.size	mj_typemap, 328
	.include	"typemap.mj.inc"
